﻿using AutoMapper;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Panel.Gate;
using MadPay724.Data.Models.UserModel;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Presentation.Routes.V1;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Upload.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MadPay724.Presentation.Controllers.Site.V1.User
{
    [ApiExplorerSettings(GroupName = "v1_Site_Panel")]
    [ApiController]
    [ServiceFilter(typeof(DocumentApproveFilter))]
    public class GatesController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GatesController> _logger;
        private readonly IUploadService _uploadService;
        private readonly IWebHostEnvironment _env;
        public GatesController(IUnitOfWork<MadpayDbContext> dbContext, IMapper mapper,
            ILogger<GatesController> logger, IUploadService uploadService,
            IWebHostEnvironment env)
        {
            _db = dbContext;
            _mapper = mapper;
            _logger = logger;
            _uploadService = uploadService;
            _env = env;
        }


        [Authorize(Policy = "RequireUserRole")]
        [ServiceFilter(typeof(UserCheckIdFilter))]
        [HttpGet(ApiV1Routes.Gate.GetGates)]
        public async Task<IActionResult> GetGates(string userId)
        {
            var gatesFromRepo = await _db.GateRepository
                .GetManyAsync(p => p.Wallet.UserId == userId, s => s.OrderByDescending(x => x.IsActive), "");


            var bankcards = _mapper.Map<List<GateForReturnDto>>(gatesFromRepo);

            return Ok(bankcards);
        }

        [Authorize(Policy = "RequireUserRole")]
        [ServiceFilter(typeof(UserCheckIdFilter))]
        [HttpGet(ApiV1Routes.Gate.GetGate, Name = "GetGate")]
        public async Task<IActionResult> GetGate(string id, string userId)
        {
            var gateFromRepo = (await _db.GateRepository
                .GetManyAsync(p => p.Id == id, null, "Wallets")).SingleOrDefault();

            if (gateFromRepo != null)
            {
                if (gateFromRepo.Wallet.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    var gate = _mapper.Map<GateForReturnDto>(gateFromRepo);

                    return Ok(gate);
                }
                else
                {
                    _logger.LogError($"کاربر   {RouteData.Values["userId"]} قصد دسترسی به درگاه دیگری را دارد");

                    return BadRequest("شما اجازه دسترسی به درگاه کاربر دیگری را ندارید");
                }
            }
            else
            {
                return BadRequest("درگاهی وجود ندارد");
            }

        }

        [Authorize(Policy = "RequireUserRole")]
        [HttpPost(ApiV1Routes.Gate.AddGate)]
        public async Task<IActionResult> AddGate(string userId, [FromForm]GateForCreateDto gateForCreateDto)
        {
            var gateFromRepo = await _db.GateRepository
                .GetAsync(p => p.WebsiteUrl == gateForCreateDto.WebsiteUrl && p.Wallet.UserId == userId);

            if (gateFromRepo == null)
            {
                var gateForCreate = new Gate()
                {
                    WalletId = gateForCreateDto.WalletId,
                    IsDirect = false,
                    IsActive = false
                };
                if (gateForCreateDto.File != null)
                {
                    if (gateForCreateDto.File.Length > 0)
                    {
                        var uploadRes = await _uploadService.UploadFileToLocal(
                            gateForCreateDto.File,
                            userId,
                            _env.WebRootPath,
                            $"{Request.Scheme ?? ""}://{Request.Host.Value ?? ""}{Request.PathBase.Value ?? ""}",
                            "Files\\Gate"
                        );
                        if (uploadRes.Status)
                        {
                            gateForCreate.IconUrl = uploadRes.Url;
                        }
                        else
                        {
                            return BadRequest(uploadRes.Message);
                        }
                    }
                    else
                    {
                        gateForCreate.IconUrl = "";
                    }
                }
                else
                {
                    gateForCreate.IconUrl = "";
                }
                var gate = _mapper.Map(gateForCreateDto, gateForCreate);

                await _db.GateRepository.InsertAsync(gate);

                if (await _db.SaveAsync())
                {
                    var gateForReturn = _mapper.Map<GateForReturnDto>(gate);

                    return CreatedAtRoute("GetGate", new { id = gate.Id, userId = userId }, gateForReturn);
                }
                else
                    return BadRequest("خطا در ثبت اطلاعات");
            }
            {
                return BadRequest("این درگاه قبلا ثبت شده است");
            }


        }
        [Authorize(Policy = "RequireUserRole")]
        [HttpPut(ApiV1Routes.Gate.UpdateGate)]
        public async Task<IActionResult> UpdateGate(string id, [FromForm]GateForCreateDto gateForUpdateDto)
        {
            var gateFromRepo = (await _db.GateRepository
                .GetManyAsync(p => p.Id == id, null, "Wallets")).SingleOrDefault();

            if (gateFromRepo != null)
            {
                if (gateFromRepo.Wallet.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    if (gateForUpdateDto.File != null)
                    {
                        if (gateForUpdateDto.File.Length > 0)
                        {
                            var uploadRes = await _uploadService.UploadFileToLocal(
                                gateForUpdateDto.File,
                                gateFromRepo.Wallet.UserId,
                                _env.WebRootPath,
                                $"{Request.Scheme ?? ""}://{Request.Host.Value ?? ""}{Request.PathBase.Value ?? ""}",
                                "Files\\Gate"
                            );
                            if (uploadRes.Status)
                            {
                                gateFromRepo.IconUrl = uploadRes.Url;
                            }
                            else
                            {
                                return BadRequest(uploadRes.Message);
                            }
                        }
                    }
                    var gate = _mapper.Map(gateForUpdateDto, gateFromRepo);
                    _db.GateRepository.Update(gate);

                    if (await _db.SaveAsync())
                        return NoContent();
                    else
                        return BadRequest("خطا در ثبت اطلاعات");
                }
                else
                {
                    _logger.LogError($"کاربر   {RouteData.Values["userId"]} قصد اپدیت به درگاه دیگری را دارد");

                    return BadRequest("شما اجازه اپدیت درگاه کاربر دیگری را ندارید");
                }
            }
            {
                return BadRequest("درگاهی وجود ندارد");
            }
        }
    }
}
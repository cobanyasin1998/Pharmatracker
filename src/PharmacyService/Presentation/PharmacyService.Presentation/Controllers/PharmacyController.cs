﻿using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Delete;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.ExcelDownload;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;


public class PharmacyController : Coban.Presentation.Controllers.Abstractions.AbstractController<
    CreatePharmacyCommandRequest, IResponse<CreatePharmacyCommandResponse, GeneralErrorDto>,
    UpdatePharmacyCommandRequest, IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>,
    DeletePharmacyCommandRequest, IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>,
    GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>,
    GetAllPharmacyQueryRequest, IResponse<GetAllPharmacyQueryResponse, GeneralErrorDto>
    >
{
    [HttpPost]
    public virtual async Task<IActionResult> ExcelDownload([FromBody] ExcelDownloadPharmacyQueryRequest excelDownloadPharmacyQuery)
    {

        var response = await Mediator!.Send(excelDownloadPharmacyQuery);
        return HandleResponse((IResponseBase)response);
    }
}
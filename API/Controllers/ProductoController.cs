using System.Collections.Generic;
using Dominio.Interface;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
using API.Services;
namespace API.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Generador_Pdf _generador;
        public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generador = new Generador_Pdf();
        }


        // endpoint para generar un PDF de productos
        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProductoDto>>> Get11([FromQuery] Params productParams)
        {
            // obtiene productos paginados segun se desee
            var products = await _unitOfWork.Productos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);

            // mapea la lista de productos a una lista de DTO
            var lstProductDto = _mapper.Map<List<ProductoDto>>(products.registros);

            //genera el pdf apartir de la lista de dto usando el generador_pdf
            var ms = _generador.Generador<ProductoDto>(lstProductDto);

            // devuelve al usuario el fileSreamResult, que devulve el archivo pdf 
            return new FileStreamResult(ms, "application/pdf");
        }
    }
}

using System.Collections.Generic;
using AutoMapper;
using Dominio.Interface;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using API.Dtos;


namespace API.Controllers
{
    
    public class MarcaController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private Generador_Pdf _generador;


        public MarcaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _generador = new Generador_Pdf(); // instancia el generador de PDF
        }

        // metodo que maneja la solicitud GET para generar un PDF solamente las marcas
        [HttpGet("Pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MarcaDto>>> Get([FromQuery] Params marcaParams)
        {
            // metodo de paginacion desde el repositorio de marca en el unitOfWork
            var pag = await _unitOfWork.Marca.paginacion(marcaParams.PageIndex, marcaParams.PageSize, marcaParams.Search);

            //mapea la lista de entidades de marca a una lista de dto
            var dto = _mapper.Map<List<MarcaDto>>(pag.registros);

            //genera  un MemoryStream utilizando el generador de pdf
            var ms = _generador.Generador<MarcaDto>(dto);

            // devuelve al usuario el fileSreamResult, que devulve el archivo pdf 
            return new FileStreamResult(ms, "application/pdf");
        }
    }
}

using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Repositories;
using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Services;
using App.Src.Modules.Customers.Application.Http.Request;
using App.Src.Modules.Customers.Domain.Models;
using App.Src.Shared.Application.Errors;
using App.Src.Shared.Application.Http.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace App.Src.Modules.Customers.Application.Http.Controllers
{
    [Produces("application/json")]
    [Route("api/client")]
    [ApiController]
    public class ClientsController : Controller
    {
        private IInsertClientService InsertClientService { get; set; }
        private IUpdateClientService UpdateClientService { get; set; }
        private IClientsRepository ClientsRepository { get; set; }
        public ClientsController(IInsertClientService insertClientService
            , IUpdateClientService updateClientService
            , IClientsRepository clientsRepository)
        {
            InsertClientService = insertClientService;
            UpdateClientService = updateClientService;
            ClientsRepository = clientsRepository;
        }
        /// <summary>
        /// Inserir Cliente
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Cliente</returns>
        /// <response code="201">Cliente</response>
        [HttpGet]
        [ProducesResponseType(201)]
        public async Task<ActionResult<DefaultResponse>> Store([FromBody] ClientsRequest.Post.Body body)
        {
            try
            {
                Clients clients = await InsertClientService.Execute(new(body.Nome, body.Email));

                return Created("",new DefaultResponse { Success = true, Data = clients });
            }
            catch (AppException ex)
            {
                return StatusCode(ex.StatusCode ?? StatusCodes.Status500InternalServerError,
                    new DefaultResponse
                    {
                        Success = false,
                        Data = ex.Message
                    });
            }
        }
        /// <summary>
        /// Buscar Cliente
        /// </summary>
        /// <param name="@params"></param>
        /// <returns>Cliente</returns>
        /// <response code="200">Cliente</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DefaultResponse>> Show([FromRoute] ClientsRequest.Show.Params @params)
        {
            try
            {
                Clients clients = await ClientsRepository.FindByClientId(@params.ClientId);

                return Ok(new DefaultResponse { Success = true, Data = clients });
            }
            catch (AppException ex)
            {
                return StatusCode(ex.StatusCode ?? StatusCodes.Status500InternalServerError,
                    new DefaultResponse
                    {
                        Success = false,
                        Data = ex.Message
                    });
            }
        }
        /// <summary>
        /// Inserir Cliente
        /// </summary>
        /// <param name="@params"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <response code="204"></response>
        [HttpGet]
        [ProducesResponseType(204)]
        public async Task<ActionResult<DefaultResponse>> Update([FromRoute] ClientsRequest.Update.Params @params, 
            [FromBody] ClientsRequest.Update.Body body)
        {
            try
            {
                await UpdateClientService.Execute(new(@params.ClientId, body.Nome, body.Email));

                return NoContent();
            }
            catch (AppException ex)
            {
                return StatusCode(ex.StatusCode ?? StatusCodes.Status500InternalServerError,
                    new DefaultResponse
                    {
                        Success = false,
                        Data = ex.Message
                    });
            }
        }
        /// <summary>
        /// Inserir Cliente
        /// </summary>
        /// <param name="queryParams"></param>
        /// <returns>Cliente</returns>
        /// <response code="204">Cliente</response>
        [HttpGet]
        [ProducesResponseType(204)]
        public async Task<ActionResult<DefaultResponse>> Delete([FromRoute] ClientsRequest.Delete.Params @params)
        {
            try
            {
                await ClientsRepository.Delete(@params.ClientId);

                return NoContent();
            }
            catch (AppException ex)
            {
                return StatusCode(ex.StatusCode ?? StatusCodes.Status500InternalServerError,
                    new DefaultResponse
                    {
                        Success = false,
                        Data = ex.Message
                    });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Repository;
using AtendeClienteService;

namespace AgendaCorreios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ICommitmentRepository _commitmentRepository;

        public AddressController(ICommitmentRepository commitmentRepository)
        {
            _commitmentRepository = commitmentRepository;
        }

        [HttpGet("{Cep}")]
        public async Task<IActionResult> GetById(string Cep)
        {
            var client = new AtendeClienteClient();

            try
            {
                var response = await client.consultaCEPAsync(Cep.Replace("-", string.Empty));

                if (response == null)
                {
                    return NotFound();
                }

                var address = response.@return;

                return Ok(new
                {
                    cep = address.cep,
                    neighborhood = address.bairro,
                    city = address.cidade,
                    state = address.uf,
                    street = address.end
                });
            }
            finally
            {
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
            
        }

    }
}

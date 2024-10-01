using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;

namespace EHospital.Application.Futures.Commands.Allergy.Create
{
    public class AllergyCreateCommandRequest : IRequest<AllergyCreateCommandResponse>
    {
        public AllergyCreateDto AllergyCreateDto { get; set; }
    }
    public class AllergyCreateCommandResponse
    {
        public string StatusCode { get; set; }
    }
    public class AllergyCreateCommandHandler : IRequestHandler<AllergyCreateCommandRequest, AllergyCreateCommandResponse>
    {
        private readonly IAllergyService _allergyService;

        public AllergyCreateCommandHandler(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        public async Task<AllergyCreateCommandResponse> Handle(AllergyCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new AllergyCreateCommandResponse();

            await _allergyService.CreateAllergyAsync(request.AllergyCreateDto);
            response.StatusCode = "201";

            return response;
        }
    }

}

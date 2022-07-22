using AkfnyServices.Business;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TraineeEntity.Handlers
{
    public class AddTraineeHandler : IRequestHandler<AddTraineeCommand, string>
    {
        private ITraineeBusiness _traineeBusiness;
        public AddTraineeHandler(ITraineeBusiness traineeBusiness)
        {
            _traineeBusiness = traineeBusiness;
        }
        public async Task<string> Handle(AddTraineeCommand request, CancellationToken cancellationToken)
        {
            var model = await _traineeBusiness.AddTrainee(request);
            return model;
        }
    }
}

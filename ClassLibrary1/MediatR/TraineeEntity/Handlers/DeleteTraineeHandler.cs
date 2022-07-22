using AkfnyServices.Business;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TraineeEntity.Handlers
{
    public class DeleteTraineeHandler : IRequestHandler<DeleteTraineeCommand, bool>
    {
        private ITraineeBusiness _traineeBusiness;
        public DeleteTraineeHandler(ITraineeBusiness traineeBusiness)
        {
            _traineeBusiness = traineeBusiness;
        }
        public async Task<bool> Handle(DeleteTraineeCommand request, CancellationToken cancellationToken)
        {
            var model = await _traineeBusiness.DeleteTrainee(request);
            return model;
        }
    }
}

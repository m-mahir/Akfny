using AkfnyServices.Business;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TraineeEntity.Handlers
{
    public class EditTraineeHandler : IRequestHandler<EditTraineeCommand, bool>
    {
        private ITraineeBusiness _traineeBusiness;
        public EditTraineeHandler(ITraineeBusiness traineeBusiness)
        {
            _traineeBusiness = traineeBusiness;
        }
        public async Task<bool> Handle(EditTraineeCommand request, CancellationToken cancellationToken)
        {
            var model = await _traineeBusiness.EditTrainee(request);
            return model;
        }
    }
}

using AkfnyServices.Business;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TraineeEntity.Handlers
{
    public class ChangeTraineeStatusHandler : IRequestHandler<ChangeTraineeStatusCommand, Data.Entities.Trainer>
    {
        private ITraineeBusiness _TraineeBusiness;
        public ChangeTraineeStatusHandler(ITraineeBusiness TraineeBusiness)
        {
            _TraineeBusiness = TraineeBusiness;
        }
        public async Task<Data.Entities.Trainer> Handle(ChangeTraineeStatusCommand request, CancellationToken cancellationToken)
        {
            var model = await _TraineeBusiness.ChangeTraineeStatus(request);
            return model;
        }
    }
}

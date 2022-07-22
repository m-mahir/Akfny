using AkfnyServices.Business;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TrainerEntity.Handlers
{
    public class ChangeLecturerStatusHandler : IRequestHandler<ChangeLecturerStatusCommand, Data.Entities.Lecturer>
    {
        private ILecturerBusiness _lecturerBusiness;
        public ChangeLecturerStatusHandler(ILecturerBusiness lecturerBusiness)
        {
            _lecturerBusiness = lecturerBusiness;
        }
        public async Task<Data.Entities.Lecturer> Handle(ChangeLecturerStatusCommand request, CancellationToken cancellationToken)
        {
            var model = await _lecturerBusiness.ChangeLecturerStatus(request);
            return model;
        }
    }
}

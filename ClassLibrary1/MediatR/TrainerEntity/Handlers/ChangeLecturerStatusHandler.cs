using AkfnyServices.Business;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TrainerEntity.Handlers
{
    public class DeleteLecturerHandler : IRequestHandler<DeleteLecturerCommand, bool>
    {
        private ILecturerBusiness _lecturerBusiness;
        public DeleteLecturerHandler(ILecturerBusiness lecturerBusiness)
        {
            _lecturerBusiness = lecturerBusiness;
        }
        public async Task<bool> Handle(DeleteLecturerCommand request, CancellationToken cancellationToken)
        {
            var model = await _lecturerBusiness.DeleteLecturer(request);
            return model;
        }
    }
}

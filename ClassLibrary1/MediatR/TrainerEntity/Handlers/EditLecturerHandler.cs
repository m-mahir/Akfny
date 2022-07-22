using AkfnyServices.Business;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TrainerEntity.Handlers
{
    public class EditLecturerHandler : IRequestHandler<EditLecturerCommand, bool>
    {
        private ILecturerBusiness _LecturerBusiness;
        public EditLecturerHandler(ILecturerBusiness LecturerBusiness)
        {
            _LecturerBusiness = LecturerBusiness;
        }
        public async Task<bool> Handle(EditLecturerCommand request, CancellationToken cancellationToken)
        {
            var model = await _LecturerBusiness.EditLecturer(request);
            return model;
        }
    }
}

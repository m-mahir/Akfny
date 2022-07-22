using AkfnyServices.Business;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.TrainerEntity.Handlers
{
    public class AddLecturerHandler : IRequestHandler<AddLecturerCommand, string>
    {
        private ILecturerBusiness _LecturerBusiness;
        public AddLecturerHandler(ILecturerBusiness LecturerBusiness)
        {
            _LecturerBusiness = LecturerBusiness;
        }
        public async Task<string> Handle(AddLecturerCommand request, CancellationToken cancellationToken)
        {
            var model = await _LecturerBusiness.AddLecturer(request);
            return model;
        }
    }
}

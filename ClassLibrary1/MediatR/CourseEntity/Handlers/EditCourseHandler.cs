using AkfnyServices.Business;
using AkfnyServices.MediatR.CourseEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.CourseEntity.Handlers
{

    public class EditCourseHandler : IRequestHandler<EditCourseCommand, bool>
    {
        public ICourseBusiness _courseBusiness;
        public EditCourseHandler(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }

        async Task<bool> IRequestHandler<EditCourseCommand, bool>.Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseBusiness.EditCourse(request);
            return true;
        }
    }

}

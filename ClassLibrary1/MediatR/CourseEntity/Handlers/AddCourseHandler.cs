using AkfnyServices.Business;
using AkfnyServices.MediatR.CourseEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.CourseEntity.Handlers
{

    public class AddCourseHandler : IRequestHandler<AddCourseCommand, bool>
    {
        public ICourseBusiness _courseBusiness;
        public AddCourseHandler(ICourseBusiness courseBusiness)
        {
            _courseBusiness = courseBusiness;
        }

        async Task<bool> IRequestHandler<AddCourseCommand, bool>.Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseBusiness.AddCourse(request);
            return true;
        }
    }

}

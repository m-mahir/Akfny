using AkfnyServices.Business;
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AkfnyServices.MediatR.CourseSuggestionEntity.Handlers
{
    public class ChangeCourseSuggestionHandler : IRequestHandler<ChangeCourseSuggestionCommand, Data.Entities.CourseSuggestion>
    {
        private ICourseSuggestionBusiness _CourseSuggestionBusiness;
        public ChangeCourseSuggestionHandler(ICourseSuggestionBusiness CourseSuggestionBusiness)
        {
            _CourseSuggestionBusiness = CourseSuggestionBusiness;
        }
        public async Task<Data.Entities.CourseSuggestion> Handle(ChangeCourseSuggestionCommand request, CancellationToken cancellationToken)
        {
            var model = await _CourseSuggestionBusiness.ChangeCourseSuggestion(request);
            return model;
        }
    }
}

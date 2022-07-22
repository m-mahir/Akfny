using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.CourseSuggestionEntity.Commands
{
    public class ChangeCourseSuggestionCommand : IRequest<Data.Entities.CourseSuggestion>
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TrainerEntity.Commands
{
    public class ChangeLecturerStatusCommand: IRequest<Data.Entities.Lecturer>
    {
        public int Id { get; set; }
        public bool isDeactivate { get; set; }
        public bool isReactivate { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TraineeEntity.Commands
{
    public class ChangeTraineeStatusCommand: IRequest<Data.Entities.Trainer>
    {
        public int Id { get; set; }
        public bool isDeactivate { get; set; }
        public bool isReactivate { get; set; }
    }
}

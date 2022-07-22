using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TraineeEntity.Commands
{
    public class DeleteTraineeCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class InterRepository : Repository <Interventions>
    {
        public InterRepository(DbContext context) : base(context)
        {
            //_context = context;
        }

        public override Interventions Delete(Interventions tentity)
        {
            throw new NotImplementedException();
        }

        public override Interventions Insert(Interventions tentity)
        {

            using (var command = _context.CreateCommand())
            {
                //command.CommandText = @"INSERT INTO Interventions VALUES(@UserId, @InterventionTypeId, @ClientId, @InterventionCost, @InterventionHour, @InterventionComments, @CreateDate, @Status, @Operater)";
                ////command.Parameters.Add(command.CreateParameter("InterventionId", tentity.InterventionId));
                //command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                //command.Parameters.Add(command.CreateParameter("InterventionTypeId", tentity.InterventionTypeId));
                //command.Parameters.Add(command.CreateParameter("ClientId", tentity.ClientId));
                //command.Parameters.Add(command.CreateParameter("InterventionCost", tentity.InterventionCost));
                //command.Parameters.Add(command.CreateParameter("InterventionHour", tentity.InterventionHour));
                //command.Parameters.Add(command.CreateParameter("InterventionComments", tentity.InterventionComments));
                //command.Parameters.Add(command.CreateParameter("CreateDate", tentity.CreateDate));
                //command.Parameters.Add(command.CreateParameter("Status", tentity.Status));
                //command.Parameters.Add(command.CreateParameter("Operater", tentity.Operater));
                ////command.ExecuteNonQuery();
                //return this.ToList(command).FirstOrDefault();
                return null;
            }


        }

        public override Interventions Update(Interventions tentity)
        {

            using (var command = _context.CreateCommand())
            {
                //command.CommandText = @"UPDATE Interventions SET InterventionCost=@InterventionCost, InterventionHour=@InterventionHour, InterventionComments=@InterventionComments, CreateDate= @CreateDate, Status=@Status,Operater=@Operater WHERE UserId=@UserId AND InterventionTypeId=@InterventionTypeId AND ClientId=@ClientId";



                ////command.Parameters.Add(command.CreateParameter("InterventionId", tentity.InterventionId));
                //command.Parameters.Add(command.CreateParameter("UserId", tentity.UserId));
                //command.Parameters.Add(command.CreateParameter("InterventionTypeId", tentity.InterventionTypeId));
                //command.Parameters.Add(command.CreateParameter("ClientId", tentity.ClientId));
                //command.Parameters.Add(command.CreateParameter("InterventionCost", tentity.InterventionCost));
                //command.Parameters.Add(command.CreateParameter("InterventionHour", tentity.InterventionHour));
                //command.Parameters.Add(command.CreateParameter("InterventionComments", tentity.InterventionComments));
                //command.Parameters.Add(command.CreateParameter("CreateDate", tentity.CreateDate));
                //command.Parameters.Add(command.CreateParameter("Status", tentity.Status));
                //command.Parameters.Add(command.CreateParameter("Operater", tentity.Operater));
                ////command.ExecuteNonQuery();
                //return this.ToList(command).FirstOrDefault();
                return null;
            }

        }
    }
}
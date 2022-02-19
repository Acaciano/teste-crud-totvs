using System;

namespace Cbyk.ATS.API.Models
{
    public abstract class EntityModel
    {
        public EntityModel()
        {
            this.Id = Guid.NewGuid();
            this.Created_At = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }

        public void AtualizaDataUpdate()
        {
            this.Updated_At = DateTime.Now;
        }
    }
}

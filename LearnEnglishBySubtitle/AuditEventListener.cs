using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studyzy.LearnEnglishBySubtitle
{
    using System;
    using global::NHibernate.Event;
    using global::NHibernate.Persister.Entity;

    [Serializable]
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
      
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var entity = @event.Entity as IAuditEntity;
            if (entity == null) return false;

            var now = DateTime.Now;
         

            Set(@event.Persister, @event.State, "UpdateTime", now, true);
            Set(@event.Persister, @event.State, "CreateTime", now);
        
            entity.UpdateTime = now;
         
          

            if (entity.CreateTime == DateTime.MinValue)
            {
                entity.CreateTime = now;
            }
            return false;
        }

     

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var entity = @event.Entity as IAuditEntity;
            if (entity == null) return false;

            var now = DateTime.Now;

            Set(@event.Persister, @event.State, "UpdateTime", now);
            Set(@event.Persister, @event.State, "CreateTime", now);

            entity.UpdateTime = now;
            entity.CreateTime = now;
       
            return false;
        }

        private static void Set(IEntityPersister persister, object[] state, string propertyName, object value, bool overwrite = false)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            if (overwrite)
            {
                state[index] = value;
            }
            else
            {
                if (state[index] is DateTime)
                {
                    var dateTimeValue = (DateTime)state[index];
                    if (dateTimeValue == DateTime.MinValue)
                    {
                        state[index] = value;
                    }
                }
                else
                {
                    var stringValue = state[index] as string;
                    if (string.IsNullOrEmpty(stringValue))
                        state[index] = value;
                }
            }
        }
    }
}

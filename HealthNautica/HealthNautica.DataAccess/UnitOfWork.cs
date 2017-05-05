using HealthNautica.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HealthNautica.DataAccess
{
    public class UnitOfWork
    {
        public CommonEntities CommonContext { get; private set; }
        public EOrderEntities EOrderContext { get; private set; }
        public PracticeEntities PracticeContext { get; private set; }

        public UnitOfWork(string practiceConnString, string eOrderConnString)
        {
            CommonContext = new CommonEntities();
            EOrderContext = new EOrderEntities(eOrderConnString);
            PracticeContext = new PracticeEntities(practiceConnString);
        }


        public void Save()
        {

            using (TransactionScope scope = new TransactionScope())
            {
                if (CommonContext.ChangeTracker.HasChanges())

                {
                    CommonContext.SaveChanges();

                }

                if (EOrderContext.ChangeTracker.HasChanges())
                {
                    EOrderContext.SaveChanges();
                }

                if (PracticeContext.ChangeTracker.HasChanges())
                {
                    PracticeContext.SaveChanges();
                }

                scope.Complete();
            }
        }


    }
}

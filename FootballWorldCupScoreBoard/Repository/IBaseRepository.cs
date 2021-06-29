using FootballWorldCupScoreBoard.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballWorldCupScoreBoard.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseDomain
    {
        public TEntity Get(long id);
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Add(List<TEntity> entities);
        public void Remove(long id);

    }
}

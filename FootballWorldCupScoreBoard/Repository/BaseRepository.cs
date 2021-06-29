using FootballWorldCupScoreBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballWorldCupScoreBoard.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseDomain
    {
        private List<TEntity> entities;

        public BaseRepository()
        {
            entities = new List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Add(List<TEntity> entities)
        {
            this.entities.AddRange(entities);
        }

        public TEntity Get(long id)
        {
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return entities;
        }

        public void Remove(long id)
        {
            entities = entities.Where(x => x.Id != id).ToList();
        }
    }
}

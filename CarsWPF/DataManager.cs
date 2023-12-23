using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWPF
{
    public class DataManager
    {
        public void Create<T>(T entity, List<T> entities, string filePath) where T : IEntity
        {
            entities.Add(entity);
            FileStorageHelper.SaveToFile(entities, filePath);
        }

        public void Delete<T>(int id, List<T> entities, string filePath) where T : IEntity
        {
            var entityToRemove = entities.FirstOrDefault(e => e.Id == id);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                FileStorageHelper.SaveToFile(entities, filePath);
            }
        }

        public void Update<T>(int id, T newEntity, List<T> entities, string filePath) where T : IEntity
        {
            var index = entities.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                entities[index] = newEntity;
                FileStorageHelper.SaveToFile(entities, filePath);
            }
        }
    }

    public interface IEntity
    {
        int Id { get; }
    }

}

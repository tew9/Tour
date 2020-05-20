using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Tour.Domains.interfaces;
using Tour.Domains.Models;

namespace Tour.DataContext
{
    public class HeroRepository
    {
        private readonly IMongoCollection<Hero> _heroCol;

        public HeroRepository(IHeroDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);
            _heroCol = database.GetCollection<Hero>(setting.HeroCollectionName);
        }

        public List<Hero> Get()
        {
            return _heroCol.Find(hero => true ).ToList();
        }

        public Hero Get(string id)
        {
            return _heroCol.Find<Hero>(hero => hero.Id == id).FirstOrDefault();
        }

        public Hero Create(Hero hero)
        {
            _heroCol.InsertOne(hero);
            return hero;
        }

        public void Update(string id, Hero heroIn)
        {
            _heroCol.ReplaceOne(hero => hero.Id == id, heroIn);
        }

        public void Remove(Hero heroDel)
        {
            _heroCol.DeleteOne(hero => hero.Id == heroDel.Id);
        }



    }
}

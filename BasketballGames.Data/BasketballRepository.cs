using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballGames.Data
{
    public class BasketballRepository
    {
        public void AddGame(Game game)
        {
            using(var context = new BasketballDataContext())
            {
                context.Games.InsertOnSubmit(game);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Game> GetGames()
        {
            using (var context = new BasketballDataContext())
            {
                return context.Games.Where(g => g.Date >= DateTime.Now).ToList();
            }
        }
        public void AddPlayer(Player player)
        {
            using (var context = new BasketballDataContext())
            {
                context.Players.InsertOnSubmit(player);
                context.SubmitChanges();
            }
        }
        public List<Game> GetPlayersByGame()
        {
            using (var context = new BasketballDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Game>(g => g.Players);
                context.LoadOptions = loadOptions;
                return context.Games.Where(g => g.MaxPeople >= g.Players.Count).ToList(); 
            }
        }
        public void AddMember(Member member)
        {
            using (var context = new BasketballDataContext())
            {
                context.Members.InsertOnSubmit(member);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Member> GetMembers()
        {
            using (var context = new BasketballDataContext())
            {
                return context.Members.ToList();
            }
        }

    }
}

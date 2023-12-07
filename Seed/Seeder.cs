using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProjectWH.Seed
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Data.YourDbContext(serviceProvider.GetRequiredService<DbContextOptions<Data.YourDbContext>>()))
            {
                // Check if there is existing data
                if (context.Users.Any() || context.Challenges.Any() || context.ChallengeProgress.Any())
                {
                    return; // Database has been seeded
                }

                SeedUsers(context);
                SeedChallenges(context);
                SeedChallengeProgress(context);
            }
        }

        private static void SeedUsers(Data.YourDbContext context)
        {
            var users = Enumerable.Range(1, 30).Select(i => new Models.User { Gamertag = $"Player{i}" });

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedChallenges(Data.YourDbContext context)
        {
            var challenges = new[]
            {
                new Models.Challenge { ChallengeName = "Headshot Kills" },
                new Models.Challenge { ChallengeName = "Longshot Kills" },
                new Models.Challenge { ChallengeName = "Hipfire Kills" },
                new Models.Challenge { ChallengeName = "Kills Shortly After Reloading" },
                new Models.Challenge { ChallengeName = "Bloodthirsty Medals" },
                new Models.Challenge { ChallengeName = "Three Kills Without Dying" },
                new Models.Challenge { ChallengeName = "Kills While Crouched" },
                new Models.Challenge { ChallengeName = "Kills While reloading" },
                new Models.Challenge { ChallengeName = "Kills While Prone" },
                new Models.Challenge { ChallengeName = "Kills While Enemy Is Stunned" },
                new Models.Challenge { ChallengeName = "Kills While You Are Stunned" },
                new Models.Challenge { ChallengeName = "Headshot Kills While Blind" },
                new Models.Challenge { ChallengeName = "Headshot Kills While Using An Optic" },
                new Models.Challenge { ChallengeName = "Headshot Kills While using a supressor" },
                new Models.Challenge { ChallengeName = "Headshot Kills While Prone" },
                new Models.Challenge { ChallengeName = "Headshot Kills Within 25 Meters" },
                new Models.Challenge { ChallengeName = "Headshot Kills With An SMG" },
                new Models.Challenge { ChallengeName = "Headshot Kills With An AR" },
                new Models.Challenge { ChallengeName = "Headshot Kills With A Sniper Rifle" },
                new Models.Challenge { ChallengeName = "Headshot Kills With An LMG" },
                new Models.Challenge { ChallengeName = "Headshot Kills With Pistols" },
                new Models.Challenge { ChallengeName = "Kills After Switching To Your Sidearm" },
                new Models.Challenge { ChallengeName = "Headshot Kills With Marksman Rifles" },
                new Models.Challenge { ChallengeName = "Headshot Kills With Battle Rifles" },
                new Models.Challenge { ChallengeName = "Ultra Kill Medals" },

                
            };

            context.Challenges.AddRange(challenges);
            context.SaveChanges();
        }

        private static void SeedChallengeProgress(Data.YourDbContext context)
        {
            var random = new Random();

            var challengeProgress = context.Users.SelectMany(u =>
                context.Challenges.Select(c => new Models.ChallengeProgress
                {
                    UserId = u.UserId,
                    ChallengeId = c.ChallengeId,
                    IsCompleted = random.NextDouble() > 0.5 
                })).ToList();

            context.ChallengeProgress.AddRange(challengeProgress);
            context.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetFinder
{
    public static class Extensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this ObjectPool<T> pool)
            where T : class, IPoolElement, new()
        {
            if (pool == null)
                yield break;

            for (int i = 0;i < pool.count;i++)
            {
                var item = pool[i];
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this DataPool<T> pool)
            where T : struct, IPoolElement
        {
            if (pool == null)
                yield break;

            for (int i = 0; i < pool.count; i++)
            {
                yield return pool.buffer[i];
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static int? GetPlanetEnemyLevel(this PlanetData planet)
        {
            if ((planet.factory?.enemySystem?.bases?.count ?? 0) > 0)
            {
                var ecnt = planet.factory?.enemySystem?.bases?.count;
                ModLogs.Trace($"{planet.displayName} - Has {ecnt} enemies");

                var bases = planet.factory?.enemySystem?.bases?.ToEnumerable();
                var units = planet.factory?.enemySystem?.units?.ToEnumerable();

                //bases.ForEach(i => ModLogs.Trace($"Base Level {i?.evolve.level}"));
                //units.ForEach(i => ModLogs.Trace($"Unit Level {i.level}"));

                var lvl = bases.Max(i => i?.evolve.level);

                if (lvl != null)
                    return lvl;

                return units.Max(i => i.level);
            }

            return null;
        }
    }
}

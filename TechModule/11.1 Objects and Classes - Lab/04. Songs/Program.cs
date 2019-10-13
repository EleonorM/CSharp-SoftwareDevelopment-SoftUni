namespace _04.Songs
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }

        public static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                var list = Console.ReadLine().Split('_');

                string type = list[0];
                string name = list[1];
                string time = list[2];
                Song song = new Song();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }

            var typeWanted = Console.ReadLine();

            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i].TypeList == typeWanted)
                {
                    Console.WriteLine(songs[i].Name);
                }
                if (typeWanted == "all")
                {
                    Console.WriteLine(songs[i].Name);
                }
            }
        }
    }
}

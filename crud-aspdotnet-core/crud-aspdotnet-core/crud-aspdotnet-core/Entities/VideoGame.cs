﻿namespace crud_aspdotnet_core.Entities
{
    public class VideoGame
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Platform { get; set; }

        public string? Developer { get; set; }

        public string? Publisher { get; set; }
    }
}

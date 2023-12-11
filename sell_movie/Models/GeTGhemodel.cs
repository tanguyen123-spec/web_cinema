namespace sell_movie.Models
{
    public class GeTGhemodel
    {
        public string TenPhim { get; set; }
        public int Gio { get; set; }
        public int Phut { get; set; }

        public TimeSpan GioChieu
        {
            get { return new TimeSpan(Gio, Phut, 0); }
        }
    }
}

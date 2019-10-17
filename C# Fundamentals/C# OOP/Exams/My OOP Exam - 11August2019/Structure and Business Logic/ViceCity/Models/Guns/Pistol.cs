namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsShot = 1;
        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            var count = 0;
            if (this.BulletsPerBarrel < BulletsShot)
            {
                if (Reload())
                {
                    this.BulletsPerBarrel -= BulletsShot;
                    count += BulletsShot;
                }
            }
            else
            {
                this.BulletsPerBarrel -= BulletsShot;
                count += BulletsShot;
            }

            return count;
        }

        private bool  Reload()
        {
            if (TotalBullets >= InitialBulletsPerBarrel)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
                return true;
            }

            return false;
        }
    }
}

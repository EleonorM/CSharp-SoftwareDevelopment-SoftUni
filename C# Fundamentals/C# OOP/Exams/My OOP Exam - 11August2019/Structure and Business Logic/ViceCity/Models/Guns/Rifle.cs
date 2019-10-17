namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsShot = 5;

        public Rifle(string name) 
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

        private bool Reload()
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

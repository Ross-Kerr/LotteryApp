using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp
{
    internal class LottoDraw
    {
        public ArrayList drawballs { get; set; } = new ArrayList();
        public int bonusBall { get; set; }

        public LottoDraw()
        {
            //create 6 unique balls
            Random rnd = new Random();
            int ball = 0;
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    ball = rnd.Next(1, 50);
                } while (drawballs.Contains(ball));
                drawballs.Add(ball);
            }
            //create unique bonus ball
            do
            {
                ball = rnd.Next(1, 50);
            } while (drawballs.Contains(ball));
            bonusBall = ball;

        }
        public int CheckTicket(Ticket t)
        {
            int winningcount = 0;

            foreach (int ball in t.balls)
            {
                if (drawballs.Contains(ball))
                {
                    winningcount++;
                }
            }
            if (winningcount == 5)
            {
                if (t.balls.Contains(bonusBall))
                {
                    return 7;
                }
            }
            return winningcount;
        }
    }
}

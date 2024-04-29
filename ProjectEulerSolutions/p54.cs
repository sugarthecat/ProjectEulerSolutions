namespace ProjectEulerSolutions
{
    internal class p54
    {
        public struct Hand
        {
            public int tier;
            public int groupValue;

            //lower = worse
            //highest is royal flush
            public int[] values;

            public Card[] cards;

            public Hand(int ranking, Card[] cards)
            {
                this.tier = ranking;
                this.values = new int[cards.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    this.values[i] = cards[i].value;
                }
                this.cards = (Card[])cards.Clone();
                groupValue = 0;
            }

            public Hand(int ranking, Card[] cards, int subvalue)
            {
                this.tier = ranking;
                this.values = new int[cards.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    this.values[i] = cards[i].value;
                }
                this.cards = (Card[])cards.Clone();
                groupValue = subvalue;
            }

            public static bool operator ==(Hand a, Hand b)
            {
                if (a.tier != b.tier)
                {
                    return false;
                }
                for (int i = 0; i < a.values.Length; i++)
                {
                    if (a.values[i] != b.values[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            public static bool operator !=(Hand a, Hand b)
            {
                return !(a == b);
            }

            public static bool operator <(Hand a, Hand b)
            {
                if (a.tier < b.tier)
                {
                    return true;
                }
                else if (b.tier < a.tier)
                {
                    return false;
                }
                //a.tier == b.tier
                if (a.groupValue < b.groupValue)
                {
                    return true;
                }
                else if (b.groupValue < a.groupValue)
                {
                    return false;
                }
                //a.groupvalue == b.groupvalue
                //determine high card
                for (int i = a.values.Length - 1; i >= 0; i--)
                {
                    if (a.values[i] > b.values[i])
                    {
                        return false;
                    }
                    if (b.values[i] > a.values[i])
                    {
                        return true;
                    }
                }
                return true;
            }

            public static bool operator >(Hand a, Hand b)
            {
                return !(b < a || b == a);
            }
        }

        public struct Card : IComparable<Card>
        {
            public char house;
            public char rank;
            public int value;

            public Card(string text)
            {
                rank = text[0];
                house = text[1];
                int[] rankValues = {  '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
                value = Array.IndexOf(rankValues, rank);
            }

            public int CompareTo(Card card)
            {
                return value.CompareTo(card.value);
            }

            public override string ToString()
            {
                return "" + rank + house;
            }
        }

        public static void Run()
        {
            string[] lines = TextReader.ReadFileLines("0054_poker.txt");
            int player1wins = 0;
            int undetermined = 0;
            int player2wins = 0;
            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    continue;
                }
                string[] cardStrings = line.Split(' ');
                Card[] player1Cards = new Card[5];
                Card[] player2Cards = new Card[5];
                for (int i = 0; i < 10; i++)
                {
                    if (i < 5)
                    {
                        player1Cards[i] = new Card(cardStrings[i]);
                    }
                    else
                    {
                        player2Cards[i - 5] = new Card(cardStrings[i]);
                    }
                }
                Array.Sort(player1Cards);
                Array.Sort(player2Cards);
                Hand player1Hand = GetHand(player1Cards);
                Hand player2Hand = GetHand(player2Cards);
                Console.WriteLine("---------------");
                if (player2Hand < player1Hand)
                {
                    Console.WriteLine("p1 wins:");
                    player1wins++;
                }
                else if (player1Hand < player2Hand)
                {
                    Console.WriteLine("p2 wins:");
                    player2wins++;
                }
                else
                {
                    Console.WriteLine("idk:");
                    undetermined++;
                }
                Console.WriteLine("\np1:");
                DisplayCards(player1Cards);
                Console.WriteLine("\np2:");
                DisplayCards(player2Cards);
            }
            Console.WriteLine("Player 1 wins: " + player1wins);
            Console.WriteLine("Player 2 wins: " + player2wins);
            Console.WriteLine("Undetermined wins: " + undetermined);
        }

        private static Hand GetHand(Card[] playerCards)
        {
            if (IsRoyalFlush(playerCards))
            {
                //no sub-tiers
                return new Hand(9, playerCards);
            }
            else if (IsStraightFlush(playerCards))
            {
                //no sub-tiers, high card comparison works
                return new Hand(8, playerCards);
            }
            else if (IsFourOfAKind(playerCards))
            {
                //4 of a kind, must include the middle if sorted
                int groupValue = playerCards[2].value;
                return new Hand(7, playerCards, groupValue);
            }
            else if (IsFullHouse(playerCards))
            {
                //3 of a kind, must include the middle if sorted
                int groupValue = playerCards[2].value;
                return new Hand(6, playerCards, groupValue);
            }
            else if (IsFlush(playerCards))
            {
                //no sub-tiers, high card comparison works
                return new Hand(5, playerCards);
            }
            else if (IsStraight(playerCards))
            {
                //no sub-tiers, high card comparison works
                return new Hand(4, playerCards);
            }
            else if (IsThreeOfAKind(playerCards))
            {
                //3 of a kind, must include the middle if sorted
                int groupValue = playerCards[2].value;
                return new Hand(3, playerCards, groupValue);
            }
            else if (IsTwoPair(playerCards))
            {
                int groupValue = playerCards[0].value;
                for (int i = 0; i < 4; i++)
                {
                    if (playerCards[i].value == playerCards[i + 1].value)
                    {
                        groupValue = playerCards[i].value;
                    }
                }
                return new Hand(2, playerCards, groupValue);
            }
            else if (IsOnePair(playerCards))
            {
                int groupValue = playerCards[0].value;
                for (int i = 0; i < 4; i++)
                {
                    if (playerCards[i].value == playerCards[i + 1].value)
                    {
                        groupValue = playerCards[i].value;
                    }
                }
                return new Hand(1, playerCards, groupValue);
            }
            return new Hand(0, playerCards);
        }

        private static bool IsRoyalFlush(Card[] playerCards)
        {
            for (int i = 0; i < playerCards.Length - 1; i++)
            {
                if (playerCards[i].house != playerCards[i + 1].house)
                {
                    //false if not the same suit
                    return false;
                }
            }
            if (playerCards[0].rank != 'A'
                || playerCards[1].rank != 'T'
                || playerCards[2].rank != 'J'
                || playerCards[3].rank != 'Q'
                || playerCards[4].rank != 'K')
            {
                return false;
            }
            return playerCards[0].value == 0;
        }

        private static bool IsStraightFlush(Card[] playerCards)
        {
            for (int i = 0; i < playerCards.Length - 1; i++)
            {
                if (playerCards[i].house != playerCards[i + 1].house || playerCards[i].value + 1 != playerCards[i + 1].value)
                {
                    //false if not the same suit or not directly adjacent values
                    return false;
                }
            }
            return true;
        }

        private static bool IsFourOfAKind(Card[] playerCards)
        {
            if (playerCards[0].rank != playerCards[1].rank)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (playerCards[i].rank != playerCards[i + 1].rank)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (playerCards[i].rank != playerCards[i + 1].rank)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsFullHouse(Card[] playerCards)
        {
            int[] values = new int[13];
            for (int i = 0; i < playerCards.Length; i++)
            {
                values[playerCards[i].value]++;
            }
            return values.Contains(3) && values.Contains(2);
        }

        private static bool IsFlush(Card[] playerCards)
        {
            for (int i = 0; i < playerCards.Length - 1; i++)
            {
                if (playerCards[i].house != playerCards[i + 1].house)
                {
                    //false if not the same suit
                    return false;
                }
            }
            return true;
        }

        private static bool IsStraight(Card[] playerCards)
        {
            for (int i = 0; i < playerCards.Length - 1; i++)
            {
                if (playerCards[i].value + 1 != playerCards[i + 1].value)
                {
                    //false if not not directly adjacent values
                    return false;
                }
            }
            return true;
        }

        private static bool IsThreeOfAKind(Card[] playerCards)
        {
            int[] values = new int[13];
            for (int i = 0; i < playerCards.Length; i++)
            {
                values[playerCards[i].value]++;
            }
            return values.Contains(3);
        }

        private static bool IsTwoPair(Card[] playerCards)
        {
            int[] values = new int[13];
            for (int i = 0; i < playerCards.Length; i++)
            {
                values[playerCards[i].value]++;
            }
            Array.Sort(values);
            Array.Reverse(values);
            return values[0] == 2 && values[1] == 2;
        }

        private static bool IsOnePair(Card[] playerCards)
        {
            int[] values = new int[13];
            for (int i = 0; i < playerCards.Length; i++)
            {
                values[playerCards[i].value]++;
            }
            return values.Contains(2);
        }

        private static void DisplayCards(Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write(cards[i].ToString() + ' ');
            }
            Console.Write('\n');
        }
    }
}
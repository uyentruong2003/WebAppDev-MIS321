//MAIN
Console.Clear();
int credit = 50;
System.Console.WriteLine("Every player starts game with 50 credits. Once you lose all the credits, or you hit the maximum of 300 credits, the game will be over.");
MainMenu(ref credit);
// END MAIN

static void MainMenu(ref int credit){
    string userChoice = GetChoice("Main Menu:","1: Game Menu,", "2: Score Board,", "3: Exit Program");
    while (userChoice != "3"){
        if (userChoice == "1"){
            // Check if the credit is eligible; only go to GAME MENU if it is.
            if (CheckCredit(ref credit)) {
                GameMenu (ref credit);
                userChoice = GetChoice("Main Menu:","1: Game Menu,", "2: Score Board,", "3: Exit Program"); //update read
            } else {
                System.Console.WriteLine("You cannot continue to the Game Menu. Press 2 for Score Board or 3 to Exit program");
                userChoice = GetChoice("Main Menu:","", "2: Score Board,", "3: Exit Program"); //update read
            }

        } else if (userChoice == "2"){
            ScoreBoard(ref credit);
            // Check if the credit is eligible. If not, exit program.
            if (CheckCredit(ref credit)){
                userChoice = GetChoice("Main Menu:","1: Game Menu,", "2: Score Board,", "3: Exit Program"); //update read
            }else {
                System.Console.WriteLine("You cannot continue playing. Proceed to exit...");
                userChoice = "3"; // update read to 3 to terminate loop
            }
        } else {
            System.Console.WriteLine("Your input is invalid. Please re-enter.");
            userChoice = GetChoice("Main Menu:","1: Game Menu,", "2: Score Board,", "3: Exit Program"); //update read
        }
    }
}

static void GameMenu(ref int credit){
    string userChoice = GetChoice ("\tGame Menu:", "1: Play Guess Ten,", "2: Play Lucky Dice,", "3: Exit to Main Menu");
    while (userChoice != "3"){
        
            if (userChoice == "1"){

                if (CheckCredit(ref credit)){
                    GuessTenMain(ref credit);
                    userChoice = GetChoice ("\tGame Menu:", "1: Play Guess Ten,", "2: Play Lucky Dice,", "3: Exit to Main Menu"); //update read

                } else {
                    System.Console.WriteLine("You cannot continue to play either game. Proceed to exit from Game Menu...");
                    userChoice = "3"; // update read to 3 to terminate loop
            }
           
            } else if (userChoice == "2"){

                if (CheckCredit(ref credit)){

                    if (credit >= 20) { // Check for the 20 credits criteria
                        LuckyDiceMain(ref credit);
                        // System.Console.Write("\t\tLuckyDiceMain. Update credit to: ");
                        // credit = int.Parse(Console.ReadLine());
                        userChoice = GetChoice ("\tGame Menu:", "1: Play Guess Ten,", "2: Play Lucky Dice,", "3: Exit to Main Menu"); //update read
        
                    }else {
                        System.Console.WriteLine("\t\tYou can't play Lucky Dice. This game requires player to have at least 20 credits.");
                        userChoice = GetChoice ("\tGame Menu:", "1: Play Guess Ten,", "", "3: Exit to Main Menu"); //update read
                    }
                    

                } else { // if credit <0 or >300
                    System.Console.WriteLine("You cannot continue to play either game. Proceed to exit from Game Menu...");
                    userChoice = "3"; // update read to 3 to terminate loop
            }
                
            
            } else { // if userChoice is neither 1 nor 2
                System.Console.WriteLine("\tYour input is invalid. Please re-enter.");
                userChoice = GetChoice ("\tGame Menu:", "1: Play Guess Ten,", "2: Play Lucky Dice,", "3: Exit to Main Menu"); //update read
            }

        
        
    }
}

static string GetChoice(string menuType, string opt1, string opt2, string opt3){
    System.Console.WriteLine();
    System.Console.Write(menuType.ToUpper());
    System.Console.Write($" Enter a number indicating your choice ({opt1} {opt2} {opt3}): ");
    return Console.ReadLine();
}

static bool CheckCredit (ref int credit){
    if (credit > 0 && credit < 300) return true;
    else{
        if (credit <= 0) System.Console.WriteLine("You have no credits left to continue");
        else System.Console.WriteLine("You reached the maximum limit of 300 credits");
        return false;
    }
}

static void ScoreBoard (ref int credit){
    System.Console.WriteLine($"Your current score is: {credit}");
}


// START GUESS TEN MAIN--------------------------------------------------------------------------------------------------------
static void GuessTenMain (ref int credit){
    Console.Clear();
    // Card value order:
    string[] valueOrder = {"Ace","2","3","4","5","6","7","8","9","10","J","Q","K"};
    // Card suit order:
    string[] suitOrder = {"Spade","Club","Diamond","Heart"};
    // Display rules
    System.Console.WriteLine("****GAME RULES****");
    System.Console.WriteLine("The player will draw 10 random cards and will be shown the first card of the row.");
    System.Console.WriteLine("The player has to guess whether the next card in the row is higher or lower than the shown card.");
    System.Console.WriteLine("If the guess is correct, the guessed card will be shown, and the player moves forward to guessing the card following after.");
    System.Console.WriteLine("The game continues until the player guesses wrong, or the row of ten ends, whichever comes first.");
    System.Console.WriteLine("\nHOW CREDITS ARE CALCULATED: ");
    System.Console.WriteLine("If the player makes it through all 10 cards, the bet credits will be tripled.");
    System.Console.WriteLine("If the player makes it through card #7, but not all 10, the bet credits will be doubled.");
    System.Console.WriteLine("If the player makes it through card #5, but not 7, no bet credits will be lost.");
    System.Console.WriteLine("If the player loses before card #5, all bet credits will be lost.\n");
    
    // Player inputs a valid number of credits to bet on:
    int bet = GetBet (ref credit);

    System.Console.Write("Click any key to draw a row of ten...");
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine();

    // Get 10 cards from the deck:
    string[] rowOfTen = GetRowOfTen(valueOrder,suitOrder);

    // Get a random card:
    string randomCard = GetRandomCard(rowOfTen, valueOrder, suitOrder);
    
    // Display the faced down row of 10:
    System.Console.WriteLine("\nThe Row of Ten is generated & faced down");
    string [] shownValues = {"#1 ", "#2 ","#3 ","#4 ", "#5 ", "#6 ", "#7 ", "#8 ", "#9 ", "#10"};
    string [] shownSuits = {"?","?","?","?","?","?","?","?","?","?"};
    DisplayCard(shownValues, shownSuits);
    
    // Proceed the game and get the number of win games:
    System.Console.Write("Press any key to start round 1...");
    Console.ReadKey();
    System.Console.WriteLine();
    int wins = PlayGuessTen(randomCard, rowOfTen, valueOrder, suitOrder, ref shownValues, ref shownSuits);
    
    // Update the credits:
    UpdateCreditGT(ref credit, bet, wins);
}
// END GUESS TEN MAIN-----------------------------------------------------------------------------------------------------------------------

// METHOD GetBet(): Prompt user to input a valid bet amount and return the bet amount ------------------------------------------------------
static int GetBet (ref int credit){
    System.Console.WriteLine("Enter a number of credits you want to bet on: ");
    string input = Console.ReadLine(); //prime read
    int bet;
    // Make sure that only numeric input is entered, and number > 0 and < the credits player has
    while (int.TryParse(input, out bet) == false || bet > credit || bet <= 0){
        System.Console.Write($"Please re-input a valid number greater than 0 and smaller than your current credit ({credit}): ");
        input = Console.ReadLine(); //update read
    }
  
    return bet;
}

// METHOD GetRowOfTen(): Return an array of 10 random, unique cards-------------------------------------------------------------
static string[] GetRowOfTen(string[] valueOrder, string[] suitOrder){
    string [] tenCards = new String [10];
    string [] tenValues = new String [10];
    string [] tenSuits = new String [10];
    
    // Get 10 unique combinations of values and suits
    for (int i = 0; i < 10; i++){
        string tempValue = valueOrder[GetRandom(0,valueOrder.Length)];
        string tempSuit = suitOrder[GetRandom(0,suitOrder.Length)]; //prime read
        
        // Check for duplicates: 
        while(tenValues.Contains(tempValue) && tenSuits.Contains(tempSuit)){
            tempValue = valueOrder[GetRandom(0,valueOrder.Length)]; //update read
            tempSuit = suitOrder[GetRandom(0,suitOrder.Length)]; //update read
        }
        tenValues[i] = tempValue;
        tenSuits[i] = tempSuit;

        // Combine value-and-suit combos into cards:
        tenCards[i] = tenValues[i] + " of " + tenSuits[i]; 
    }
         
    return tenCards;       
}

// METHOD: GetRandomCard - pick an 11th card that's different than ones in the row of ten
static string GetRandomCard(string[] rowOfTen, string[] valueOrder, string[] suitOrder){
    string tempValue = valueOrder[GetRandom(0,valueOrder.Length)];
    string tempSuit = suitOrder[GetRandom(0, suitOrder.Length)];
    string tempCard = tempValue + " of " + tempSuit;
    while (rowOfTen.Contains(tempCard)){
    tempValue = valueOrder[GetRandom(0,valueOrder.Length)];
    tempSuit = suitOrder[GetRandom(0, suitOrder.Length)];
    tempCard = tempValue + " of " + tempSuit;
    }
    return tempCard;
}


// METHOD GetRandom(): Return a random index within that array
static int GetRandom(int start, int end){
    Random rnd = new Random();
    int index = rnd.Next(start, end);
    return index;
}

// METHOD PlayGuessTen(): Start playing the game and return the # wins---------------------------------------------------------------------------------

static int PlayGuessTen(string randomCard, string[] rowOfTen, string[] valueOrder, string[] suitOrder, ref string[] shownValues, ref string[] shownSuits){
    Console.Clear();
    int wins = 0;
    // Display the random card
    FlipRandomCard(randomCard);
    System.Console.WriteLine($"The random card: {randomCard}");
    string shownCard = randomCard;
    
    // get guess of the first card in row:
    int num = 1;
    int index = 0; //prime read
    System.Console.WriteLine($"\n ROUND {num}:");
    string guessedCard = rowOfTen[index];
    string guess = GetGuess(num, shownCard);

    

    // Proceed to next round when the player guesses correctly
    while ( IsCorrect(num, guess, shownCard, guessedCard, valueOrder, suitOrder, ref shownValues, ref shownSuits) && index < rowOfTen.Length-1){
            // Reveal the previously guessed card, increment wins:
            FlipCardInRow(index, guessedCard, ref shownValues, ref shownSuits);
            shownCard = guessedCard;
            System.Console.WriteLine($"\nCard #{num}: {shownCard}");
            wins++;
          
            // move up to the next round & get next guess:
            num++;
            index ++; //update read
            System.Console.WriteLine($"\n ROUND {num}:");
                
            // get guess of the next card:
            guessedCard = rowOfTen[index];
            guess = GetGuess(num, shownCard);
    }
    
    // make sure win in round 10 is counted properly
    if (IsCorrect(num, guess, shownCard, guessedCard, valueOrder, suitOrder, ref shownValues, ref shownSuits)) wins++;
    // show the guessed card afterwards regardless of correct/ wrong result:
    FlipCardInRow(index, guessedCard, ref shownValues, ref shownSuits);

    // Print & return result
    System.Console.WriteLine($"\nNumber of correct guesses: {wins}");
    return wins;
}

// METHOD GetGuess: Return user guess
static string GetGuess(int num, string currentCard){
    System.Console.Write($"Enter your guess- Do you think card #{num} in row is 'higher' or 'lower' than {currentCard}? ");
    string guess = Console.ReadLine(); // prime read
    // Input Validation:
    while (guess.ToLower() != "higher" && guess.ToLower() != "lower"){
        System.Console.Write("Please only enter your guess as 'higher' or 'lower': ");
        guess = Console.ReadLine(); // update read
        
    }
    return guess;
}

// METHOD IsCorrect(): Return T/F for the result
static bool IsCorrect(int num, string guess, string currentCard, string nextCard, string[] valueOrder, string[] suitOrder, ref string[] shownValues, ref string[] shownSuits){
    //Compare the cards:
    string result = CompareCards(nextCard, currentCard, valueOrder, suitOrder);

    //Check the result:
    if (guess.ToLower() == result){
        Console.Clear();
        System.Console.WriteLine("Your guess is correct!");
        System.Console.WriteLine($"Card #{num} is {nextCard}.");
        return true;
    }
    else {
        Console.Clear();
        System.Console.WriteLine("Your guess is wrong! You lose!");
        System.Console.WriteLine($"Card #{num} is {nextCard}. The correct answer should be '{result}'.");
        return false;
    }
}

// METHOD CompareCards(): Compare the cards'values; if equal values, compare their suits
static string CompareCards (string card1, string card2, string[] valueOrder, string[] suitOrder){
    //Split the cards into their components- values and suits
    string value1 = card1.Split(" of ")[0];
    string suit1 = card1.Split(" of ")[1];
    string value2 = card2.Split(" of ")[0];
    string suit2 = card2.Split(" of ")[1];
    // if the value of card 1 has greater index in the valueOrder array than that of card 2 --> return "higher"
    if (GetIndex(value1,valueOrder) > GetIndex(value2,valueOrder)) return "higher";
    // if the value of card 1 has smaller index in the valueOrder array than that of card 2 --> return "lower"
    else if (GetIndex(value1,valueOrder) < GetIndex(value2,valueOrder)) return "lower";
    // if the values of both cards have the same index in the valueOrder array --> check their suits
    else{ 
        // if the suit of card 1 has greater index in the valueOrder array than that of card 2 --> return "higher"
        if (GetIndex(suit1,suitOrder) > GetIndex(suit2,suitOrder)) return "higher";
        // if the suit of card 1 has smaller index in the valueOrder array than that of card 2 --> return "lower"
        else return "lower";
    }

}
// METHOD GetIndex(): Return the index of the element (value / suit) in the orderArr (valueOrder / suitOrder)
static int GetIndex (string element, string[] orderArr){
    int i = 0;
    while (element != orderArr[i] && i< orderArr.Length){
        i++;
    }
    return i;
}

// METHOD FlipCardInRow(): to flip the card in the row one by one each round
static void FlipCardInRow(int index, string card, ref string[] value, ref string[] suit){
    value[index] = DrawValue(card.Split(" of ")[0]);
    suit[index] = DrawSuit(card.Split(" of ")[1]);
    DisplayCard(value, suit);
}

// METHOD FlipRandomCard (): to flip the random card
static void FlipRandomCard(string randomCard){
    string value = DrawValue(randomCard.Split(" of ")[0]);
    string suit = DrawSuit (randomCard.Split(" of ")[1]);
    System.Console.WriteLine(" ___________ ");
    System.Console.WriteLine("|           |");
    System.Console.WriteLine($"|{value}        |");
    System.Console.WriteLine("|           |");
    System.Console.WriteLine($"|     {suit}     |");
    System.Console.WriteLine("|           |");
    System.Console.WriteLine($"|        {value}|");
    System.Console.WriteLine("|___________|");
}

// METHOD DrawValue(): to determine which symbol will be displayed for which value
static string DrawValue(string value){
    switch (value){
        
        case "Ace":
        return " A ";
        break;

        case "2":
        return " 2 ";
        break;

        case "3":
        return " 3 ";
        break;

        case "4":
        return " 4 ";
        break;

        case "5":
        return " 5 ";
        break;

        case "6":
        return " 6 ";
        break;

        case "7":
        return " 7 ";
        break;

        case "8":
        return " 8 ";
        break;

        case "9":
        return " 9 ";
        break;

        case "10":
        return "10 ";
        break;

        case "J":
        return " J ";
        break;

        case "Q":
        return " Q ";
        break;

        default:
        return " K ";
        break;
    }
}

// METHOD DrawSuit(): to determine which symbol will be displayed for which suit
static string DrawSuit(string suit){
     switch (suit){

        case "Spade":
        return "♠";
        break;

        case "Club":
        return "♣";
        break;

        case "Diamond":
        return "♦";
        break;

        default:
        return "♥";
        break;
    }
}

// METHOD DisplayCard(): to plot out the row of cards
static void DisplayCard (string[] value, string[] suit){
    System.Console.WriteLine(" ___________  ___________  ___________  ___________  ___________  ___________  ___________  ___________  ___________  ___________");
    System.Console.WriteLine("|           ||           ||           ||           ||           ||           ||           ||           ||           ||           |");
    System.Console.WriteLine($"|{value[0]}        ||{value[1]}        ||{value[2]}        ||{value[3]}        ||{value[4]}        ||{value[5]}        ||{value[6]}        ||{value[7]}        ||{value[8]}        ||{value[9]}        |");
    System.Console.WriteLine("|           ||           ||           ||           ||           ||           ||           ||           ||           ||           |");
    System.Console.WriteLine($"|     {suit[0]}     ||     {suit[1]}     ||     {suit[2]}     ||     {suit[3]}     ||     {suit[4]}     ||     {suit[5]}     ||     {suit[6]}     ||     {suit[7]}     ||     {suit[8]}     ||     {suit[9]}     |");
    System.Console.WriteLine("|           ||           ||           ||           ||           ||           ||           ||           ||           ||           |");
    System.Console.WriteLine($"|        {value[0]}||        {value[1]}||        {value[2]}||        {value[3]}||        {value[4]}||        {value[5]}||        {value[6]}||        {value[7]}||        {value[8]}||        {value[9]}|");
    System.Console.WriteLine("|___________||___________||___________||___________||___________||___________||___________||___________||___________||___________|");
}


// METHOD UpdateCreditGT(): Calculate the credits after the game concludes
static void UpdateCreditGT (ref int credit, int bet, int wins){
    if (wins == 10) credit = credit + bet*2;
    else if (wins >= 7 && wins < 10) credit = credit + bet;
    else if (wins >=5 && wins < 7) credit = credit + 0;
    else credit = credit - bet;
    LimitCredit(ref credit);
    System.Console.WriteLine($"Your updated credit: {credit}");
}

// METHOD LimitCredit(): to cap the credits in the range 0-300 only
static void LimitCredit (ref int credit){
    if (credit >= 300) credit = 300;
    if (credit <=0) credit = 0;
}


//START LUCKY DICE MAIN --------------------------------------------------------------------------------------------------------------------------
static void LuckyDiceMain (ref int credit){
    Console.Clear(); 
    System.Console.WriteLine("**GAME RULES**");
    System.Console.WriteLine("The player will play 5 rounds, competing against the computer.");
    System.Console.WriteLine("In each round, the player will roll 6 dices first, then it comes the computer's turn.");
    System.Console.WriteLine("The score of each player in each round will be calculated by adding up the results of 6 dices.");
    System.Console.WriteLine("If the player has higher score than the computer, the player wins; if the opposite happens, the player loses; else, the two break even.");
    System.Console.WriteLine("After all 5 rounds, if the player wins 3 out of 5 rounds, the player wins; else, the player loses.");
    System.Console.WriteLine("\nHOW CREDITS ARE CALCULATED:");
    System.Console.WriteLine("If the player wins the game, the bet credits will be doubled.");
    System.Console.WriteLine("If the player loses the game, all bet credits will be lost.");
    System.Console.WriteLine("You cannot bet more than 50 credits for this game.\n");

// Get a valid bet:
int bet = GetBet(ref credit);
while (bet > 50){
    System.Console.WriteLine("You cannot bet more than 50 credits for this game");
    bet = GetBet(ref credit);
}
// Play Lucky Dice:
int wins = PlayLuckyDice();
//Update Credits:
UpdateCreditLD(ref credit, bet, wins);
}

// END LUCKY DICE MAIN ---------------------------------------------------------------------------------------------------------------------------

// METHOD PlayLuckDice: Proceed to the game and return the number of rounds the player wins ------------------------------------------------------
static int PlayLuckyDice(){
    int wins = 0;
    for (int i = 0; i <5; i++){
        System.Console.WriteLine($"Press a random key to start ROUND {i+1}...");
        Console.ReadKey();
        Console.Clear();
        System.Console.WriteLine($"\nROUND {i+1}:");
        int playerScore = PlayerTurn();
        System.Console.WriteLine();
        System.Console.WriteLine("Press a random key to start COMPUTER's TURN...");
        Console.ReadKey();
        Console.Clear();
        int compScore = CompTurn();
        string result = RoundResult(playerScore, compScore);
        System.Console.WriteLine();
        wins = CountWins(result, ref wins);
    }
    System.Console.WriteLine("Press a random key to see result...");
        Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine($"You win {wins} out of 5 rounds.");
    if (wins >= 3) System.Console.WriteLine("YOU WIN THIS GAME!");
    else System.Console.WriteLine("YOU LOST! GAME OVER.");
    return wins;
}

// METHOD CountWins(): Count number of wins
static int CountWins(string result, ref int wins){
    if (result == "win") {
        wins++;
        System.Console.WriteLine("You win this round!");
    } else if (result == "lose"){
        System.Console.WriteLine("You lose this round!");
    } else {
        System.Console.WriteLine("This round is break-even.");
    }
    return wins;
}
//METHOD RoundResult: return the result at the end of each round -----------------------------------------------------------------------------
static string RoundResult(int playerScore, int compScore){
    if (playerScore > compScore) return "win";
    else if (playerScore < compScore) return "lose";
    else return "break-even";
    
}

//METHOD ComputerTurn: proceed to the Computer's turn and return the score -----------------------------------------------------------------
static int CompTurn(){
    System.Console.WriteLine("\n-------------COMPUTER'S TURN--------------- ");
    int score = 0;
    int[] numArr = new int[6];
    for (int i = 0; i<6; i++){
        int numb = GetRandom(1,7);
        System.Console.WriteLine($"Dice {i+1}: {numb}");
        numArr[i] = numb; //add into numArr to draw the dice
        score += numb;
    }
    DrawRowOfDice(numArr);
    System.Console.WriteLine($"The computer's score for this round: {score}");
    return score;
}

//METHOD PlayerTurn: Proceed to the Player's turn and return the score ---------------------------------------------------------------------------
static int PlayerTurn(){
    System.Console.WriteLine("\n-------------PLAYER'S TURN---------------");
    int score = 0;
    int[] numArr = new int[6];
    for (int i = 0; i<6; i++){
        System.Console.WriteLine("Press a random key to roll the dice...");
        Console.ReadKey();
        System.Console.WriteLine();
        int numb = GetRandom(1,7);
        System.Console.WriteLine($"Dice {i+1}: {numb}");
        DrawOneDice(numb);
        numArr[i] = numb; //add into numArr to draw the dice
        score += numb;
    } 
    System.Console.WriteLine("Your row of dice: ");
    DrawRowOfDice(numArr);
    System.Console.WriteLine($"Your score for this round: {score}");
    return score;
}


// METHOD UpdateCreditLD: Update credit at the end of Lucky Dice Game ----------------------------------------------------------------------------
static void UpdateCreditLD(ref int credit, int bet, int wins){
    if (wins >= 3) credit += bet;
    else credit -= bet;
    LimitCredit(ref credit);
    System.Console.WriteLine($"Your current credit is now updated to: {credit}");
}


static string[] DrawDice (int number){
    string[] dice = new string [3];
    switch (number){
        
        case 1:   
        dice[0] = "|         |";
        dice[1] = "|    O    |";
        dice[2] = "|         |";
        break;

        case 2:
        dice[0] = "| O       |";
        dice[1] = "|         |";
        dice[2] = "|       O |";
        break;

        case 3:
        dice[0] = "| O       |";
        dice[1] = "|    O    |";
        dice[2] = "|       O |";
        break;

        case 4:
        dice[0] = "| O     O |";
        dice[1] = "|         |";
        dice[2] = "| O     O |";
        break;

        case 5:
        dice[0] = "| O     O |";
        dice[1] = "|    O    |";
        dice[2] = "| O     O |";
        break;

        default:
        dice[0] = "| O     O |";
        dice[1] = "| O     O |";
        dice[2] = "| O     O |";
        break;

    }
    return dice;
}

static void DrawOneDice(int number){
    string[] dice = DrawDice(number);
    System.Console.WriteLine(" --------- ");
    System.Console.WriteLine($"{dice[0]}");
    System.Console.WriteLine($"{dice[1]}");
    System.Console.WriteLine($"{dice[2]}");
    System.Console.WriteLine(" --------- ");
}


static void DrawRowOfDice(int[] numArr){
    string[] dice1 = DrawDice(numArr[0]);
    string[] dice2 = DrawDice(numArr[1]);
    string[] dice3 = DrawDice(numArr[2]);
    string[] dice4 = DrawDice(numArr[3]);
    string[] dice5 = DrawDice(numArr[4]);
    string[] dice6 = DrawDice(numArr[5]);
    
    System.Console.WriteLine(" ---------   ---------   ---------   ---------   ---------   --------- ");
    System.Console.WriteLine($"{dice1[0]} {dice2[0]} {dice3[0]} {dice4[0]} {dice5[0]} {dice6[0]}");
    System.Console.WriteLine($"{dice1[1]} {dice2[1]} {dice3[1]} {dice4[1]} {dice5[1]} {dice6[1]}");
    System.Console.WriteLine($"{dice1[2]} {dice2[2]} {dice3[2]} {dice4[2]} {dice5[2]} {dice6[2]}");
    System.Console.WriteLine(" ---------   ---------   ---------   ---------   ---------   ---------");

}

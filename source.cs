using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");

        int runs = 1000000; // the number of runs to simulate
        int count = 0;
        for (int k = 0; k <= runs; k++) {
            count += run();
        }

        Console.WriteLine($"{count} successes out of {runs} runs");
        Console.WriteLine($"Expect a win {(count > 0 ? $"every {(int) runs/count} games" : "never")}");

    }

    public static Random random = new Random();
    public static int m = 1000; // generate random number up to (and not including)
    public static int l = 20; // length of board

    // perform one complete run of the board until success, or no more numbers can be added
    public static int run() {
        int skips = 0; // number of skips allowed
        var board = new Dictionary<int, int?>(); // initialise empty board
        for (int i = 1; i <= l; i++)
        {
            board.Add(i, null);
        }
        
        // repeat until there are no unassigned spaces on the board
        while (board.ContainsValue(null)){
            int n = random.Next(1, m); // pick a random number n between 1 and 999 (inclusive)
            (bool b, board) = assignOptimally(board, n); // assign number n to optimal position on board

            if (!b) { // if n cannot be validly assigned to any position
                if (skips == 0){ // if no skips left, return 0 (failure)
                    return 0;
                } // else decrement skip counter
                skips--;
            }
        }
        return 1;
    }

    // assign a number n to the best possible position on a board
    public static (bool, Dictionary<int, int?>) assignOptimally(Dictionary<int,int?> board, int n) {
        int i = (int) Math.Round((double)n*board.Count/m); // find theoretical best index for n
        i = i == 0 ? 1 : i; // if index is 0, make it 1

        // if n is already on the board, return current board configuration
        if (board.ContainsValue(n)) {
            return (true, board);
        }

        // if the theoretical best index for n is empty, assign n to this position and return the new board
        if (board[i] == null) {
            board[i] = n;
            return (true, board);
        }

        // if the number in the theoretical best position for n is less than n
        if (board[i] < n) {
            // loop through all positions ahead
            for (int j = i+1; j <= board.Count; j++){
                // assign n to next available position and return board
                if (board[j] == null){
                    board[j] = n;
                    return (true, board);
                } else if (board[j] > n) { // if we meet a position with a value greater than n, return failure
                    return (false, board);
                }
            }
            return (false, board); // if we reach the end of the board, return failure
        }

        // if the number in the theoretical best position for n is more than n
        // loop through all positions ahead
        for (int j = i; j >= 1; j--){
            // assign n to next available position and return board
            if (board[j] == null){
                board[j] = n;
                return (true, board);
            } else if (board[j] < n) { // if we meet a position with a value greater than n, return failure
                return (false, board);
            }
        }
        return (false, board); // if we reach the start of the board, return failure
    }
}

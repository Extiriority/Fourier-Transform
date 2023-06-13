using System.Diagnostics;
using System.Numerics;
//The DFT function is implemented using a nested loop approach to perform the DFT algorithm.

int dataSize = 1500;
Complex[] inputData = GenerateInputData(dataSize);

// Start the stopwatch
Stopwatch stopwatch = Stopwatch.StartNew();

// Compute DFT
Console.WriteLine("DFT Example:");
Complex[] dftResult = Dft(inputData);

// Stop the stopwatch
stopwatch.Stop();

// Display the results
Console.WriteLine("Input Data: ");
DisplayComplexArray(inputData);
Console.WriteLine();

Console.WriteLine("DFT Result: ");
DisplayComplexArray(dftResult);

// Display the execution time
Console.WriteLine();
Console.WriteLine("Execution Time: " + stopwatch.Elapsed);

static Complex[] GenerateInputData(int dataSize) {
    Complex[] inputData = new Complex[dataSize];

    // Generate random complex numbers
    Random random = new Random();
    for (int i = 0; i < dataSize; i++) {
        double real = random.NextDouble();
        double imag = random.NextDouble();
        inputData[i] = new Complex(real, imag);
    }

    return inputData;
}

static Complex[] Dft(Complex[] inputData) {
    int length = inputData.Length;
    Complex[] result = new Complex[length];
    
    //The DFT algorithm is implemented using a nested loop approach
    //The outer loop iterates over the output elements
    //The inner loop iterates over the input elements
    for (int k = 0; k < length; k++) {
        Complex sum = 0;

        for (int n = 0; n < length; n++) {
            Complex exponent = Complex.FromPolarCoordinates(1, -2 * Math.PI * k * n / length);
            sum += inputData[n] * exponent;
        }
        result[k] = sum;
    }
    return result;
}

static void DisplayComplexArray(Complex[] array) {
    foreach (Complex element in array) {
        Console.WriteLine(element);
    }
}
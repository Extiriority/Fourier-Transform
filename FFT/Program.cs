using System.Diagnostics;
using System.Numerics;
//The FFT function is implemented using a recursive divide-and-conquer approach to perform the FFT algorithm.

// complex is a built-in type in .NET Core that represents a complex number meaning
// that it has a real and imaginary part
// Generate large input data (100,000 data points)
int dataSize = 100000;
Complex[] inputData = GenerateInputData(dataSize);

// Compute FFT
Console.WriteLine("FFT Example:");
Fft(inputData);
Console.WriteLine();

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
// Start the stopwatch
Stopwatch stopwatch = Stopwatch.StartNew();
// Compute the FFT
Complex[] fftResult = Fft(inputData);
// Stop the stopwatch
stopwatch.Stop();

// Display the results
Console.WriteLine("Input Data: ");
DisplayComplexArray(inputData);
Console.WriteLine();

Console.WriteLine("FFT Result: ");
DisplayComplexArray(fftResult);

// Display the execution time
Console.WriteLine();
Console.WriteLine("Execution Time: " + stopwatch.Elapsed);

static Complex[] Fft(Complex[] inputData) {
    int length = inputData.Length;

    if (length <= 1)
        return inputData;
    
    //The FFT algorithm is recursive and it needs to split the input data
    Complex[] even = new Complex[length / 2];
    Complex[] odd = new Complex[length / 2];
    //split the input data into even and odd parts
    for (int i = 0; i < length / 2; i++) {
        even[i] = inputData[2 * i];
        odd[i] = inputData[2 * i + 1];
    }
    //recursively compute the FFT of the even and odd parts (divide and conquer
    Complex[] evenResult = Fft(even);
    Complex[] oddResult = Fft(odd);
    //combine the results of the even and odd parts
    //the FFT is periodic so we need to compute the result for the first half of the data
    Complex[] result = new Complex[length];
    //the first half of the result is the even results plus the odd results multiplied by a factor
    for (int k = 0; k < length / 2; k++) {
        Complex t = Complex.FromPolarCoordinates(1, -2 * Math.PI * k / length) * oddResult[k];
        result[k] = evenResult[k] + t;
        result[k + length / 2] = evenResult[k] - t;
    }

    return result;
}

//this method is used to display the results
void DisplayComplexArray(Complex[] array) {
    foreach (Complex element in array) {
        Console.WriteLine(element);
    }
}
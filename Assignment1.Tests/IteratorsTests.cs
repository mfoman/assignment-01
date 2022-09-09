namespace Assignment1.Tests;

using Assignment1;

public class IteratorsTests
{
    [Fact]
    public void Flatten_can_flatten()
    {
        // Arrange
        var list1 = new List<int>() {1, 2, 3, 4, 5, 6};
        var list2 = new List<int>() {7, 8, 9, 10, 11, 12};
        var list3 = new List<int>() {13, 14, 15, 16, 17, 18};
        var superList = new List<List<int>>(){list1, list2, list3};

        var expected = list1.Concat(list2).Concat(list3);

        // int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        // string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } };
        // IEnumerable.Cast<T>

        // Act
        var res = Iterators.Flatten<int>(superList);

        // Assert
        res.Should().Equal(expected);
    }

    [Fact]
    public void Filter_can_filter_even_numbers() {
        
        // arrange
        var listOne = new List<int>() {1,2,3,4,5,6,7,8,9};
        var expected = new List<int>() {2,4,6,8};
        
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        // act
        var result = Iterators.Filter<int>(listOne, even);

        // assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void Filter_can_filter_vowels() {
        
        // arrange
        var listOne = new List<char>() {'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E'};
        var expected = new List<char>() {'a', 'A', 'e', 'E'};
        
        Predicate<char> vowel = Vowel;
        bool Vowel(char i) => "aeiouæøå".Contains(Char.ToLower(i));

        // act
        var result = Iterators.Filter<char>(listOne, vowel);

        // assert
        result.Should().Equal(expected);
    }
}
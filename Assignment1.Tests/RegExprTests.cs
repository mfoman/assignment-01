namespace Assignment1.Tests;

using Assignment1;

public class RegExprTests
{
    [Fact]
    public void SplitLine_can_split_list_of_strings_and_returns_list_of_words()
    {
        // arrange
        var listOne = new List<string>() { "this is a test", "hello world" };
        var expected = new List<string>() { "this", "is", "a", "test", "hello", "world" };

        // act
        var result = RegExpr.SplitLine(listOne);

        // assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void Resolution_can_read_resolutions_and_return_list_of_resolution_tuples()
    {
        // arrange
        var listOne = new List<string>() {
            "1920x1080",
            "1024x768, 800x600, 640x480",
            "320x200, 320x240, 800x600", "1280x960"
        };

        var expected = new List<(int, int)>() {
            (1920, 1080),
            (1024, 768),
            (800, 600),
            (640, 480),
            (320, 200),
            (320, 240),
            (800, 600),
            (1280, 960)
        };

        // act
        var result = RegExpr.Resolution(listOne);

        // assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void InnerText_can_get_inner_text_from_a_tags()
    {
        // arrange
        var html =
            @"
            <div>
                <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='https://en.wikipedia.org/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='https://en.wikipedia.org/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='https://en.wikipedia.org/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='https://en.wikipedia.org/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='https://en.wikipedia.org/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='https://en.wikipedia.org/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p>
            </div>
            ";

        var searchTag = "a";

        var expected = new List<string>()
        {
            "theoretical computer science",
            "formal language",
            "characters",
            "pattern",
            "string searching algorithms",
            "strings"
        };

        // act
        var result = RegExpr.InnerText(html, searchTag);

        // assert
        result.Should().Equal(expected);
    }

    [Fact]
    public void InnerText_can_get_inner_text_from_p_tag_with_nested_tags()
    {
        // arrange
        var html =
            @"
            <div>
                <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
            </div>
            ";

        var searchTag = "p";

        var expected = new List<string>()
        {
            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.",
        };

        // act
        var result = RegExpr.InnerText(html, searchTag);

        // assert
        result.Should().Equal(expected);
    }
}

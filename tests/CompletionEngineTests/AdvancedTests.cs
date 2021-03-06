using Xunit;

namespace CompletionEngineTests
{
    public class AdvancedTests : XamlCompletionTestBase
    {
        [Fact]
        public void WellKnown_Brushes_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"", "Re", "Red");
        }

        [Fact]
        public void WellKnown_ThemeKeys_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"{DynamicResource ", "Theme", "ThemeBackgroundBrush");
        }

        [Fact]
        public void Extension_With_CtorArgument_Class_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"{x:Static ", "Brus", "Brushes");
        }

        [Fact]
        public void Extension_With_CtorArgument_Static_Properties_Values_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"{x:Static ", "Brushes.Re", "Brushes.Red");
        }

        [Fact]
        public void Extension_Property_With_WellKnown_Value_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"{Binding RelativeSource=", "Se", "Self");
        }

        [Fact]
        public void Extension_With_CtorArgument_Enum_Should_Be_Completed()
        {
            AssertSingleCompletion("<UserControl Background=\"{Binding RelativeSource={RelativeSource ", "Se", "Self");
        }

        [Fact]
        public void Extension_With_CtorArgument_Type_Should_Be_Completed()
        {
            AssertSingleCompletion("<DataTemplate DataType=\"{x:Type ", "But", "Button");
        }

        [Fact]
        public void Property_Of_Type_Type_Type_Should_Be_Completed()
        {
            AssertSingleCompletion("<DataTemplate DataType=\"", "But", "Button");
        }

        [Fact]
        public void TemplateBinding_AvaloniaPropeties_Should_Be_Completed()
        {
            AssertSingleCompletion("<ContentPresenter Background=\"{TemplateBinding ", "Back", "Background");
        }

        [Fact]
        public void StyleSelector_Control_Types_Should_Be_Completed()
        {
            AssertSingleCompletion("<Style Selector=\"", "But", "Button");
        }

        [Fact]
        public void StyleSelector_Some_WellKnown_Keywords_Should_Be_Completed()
        {
            var compl =  GetCompletionsFor("<Style Selector=\"").Completions;

            Assert.Contains(compl, v => v.InsertText == ">");
            Assert.Contains(compl, v => v.InsertText == ".");
            Assert.Contains(compl, v => v.InsertText == "#");
            Assert.Contains(compl, v => v.InsertText == "/template/");
        }

        [Fact]
        public void StyleSelector_Some_WellKnown_PseudoClasses_Should_Be_Completed()
        {
            var compl = GetCompletionsFor("<Style Selector=\"").Completions;

            Assert.Contains(compl, v => v.InsertText == ":pointerover");
            Assert.Contains(compl, v => v.InsertText == ":disabled");
            Assert.Contains(compl, v => v.InsertText == ":focus");
        }

        [Fact]
        public void Image_Source_Uris_Should_Be_Completed()
        {
            AssertSingleCompletion("<Image Source=\"", "resm:", "resm:CompletionEngineTests.Test.bmp?assembly=CompletionEngineTests");
        }
    }
}
require 'rspec'
require_relative 'reverse_words'

describe ReverseWords do

  it 'should leave one word alone' do
    test = "butts"
    ReverseWords.reverse_sentence!(test)
    test.should == "butts"
  end

  it 'should swap two letters' do
    test = "a b"
    ReverseWords.reverse_sentence!(test)
    test.should == "b a"
  end

  it 'should swap two words' do
    test = "butts lol"
    ReverseWords.reverse_sentence!(test)
    test.should == "lol butts"
  end

  it 'should reverse a phrase with punctuation' do
    test = "dude, wow"
    ReverseWords.reverse_sentence!(test)
    test.should == "wow dude,"
  end

  it 'should reverse a full sentence' do
    test = "Coding for Interviews contains too many gifs."
    ReverseWords.reverse_sentence!(test)
    test.should == "gifs. many too contains Interviews for Coding"
  end
end
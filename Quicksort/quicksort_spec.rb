require 'rspec'
require_relative './quicksort.rb'

describe "Quicksort" do
  before(:each) do
    @quicksort = Quicksort.new
  end

  it 'should just return one item' do
    @quicksort.quicksort([42]).should == [42]
  end

  it "should sort 2 items" do
    @quicksort.quicksort([3, 2]).should == [2, 3]
  end

  it "should handle arrays with same items" do
    @quicksort.quicksort([1, 1, 1, 1, 1, 1]).should == [1, 1, 1, 1, 1, 1]
  end

  it "should leave sorted arrays sorted" do
    @quicksort.quicksort([1, 2, 3, 4, 5, 6, 7, 8, 9]).should == [1, 2, 3, 4, 5, 6, 7, 8, 9]
  end
end
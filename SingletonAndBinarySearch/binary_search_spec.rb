require "rspec"
require_relative 'binary_search.rb'

describe "BinarySearch" do
  before(:each) do
    @binary_search = BinarySearch.new
  end

  it "should find item in array with 1 elements" do
    @binary_search.find_item([5], 5).should == 0
  end

  it "should return nil when item cannot be found" do
    @binary_search.find_item([5], 3).should == nil
  end

  it "should find item in array with 2 elements" do
    @binary_search.find_item([1, 3], 3).should == 1
  end

  it "should find middle item" do
    @binary_search.find_item([-3, -1, 5, 8, 24], 5).should == 2
  end

  it "should find item in first part" do
    @binary_search.find_item([-3, -1, 5, 8, 24], -1).should == 1
  end

  it "should find item in last part" do
    @binary_search.find_item([-3, -1, 5, 8, 24], 24).should == 4
  end
end
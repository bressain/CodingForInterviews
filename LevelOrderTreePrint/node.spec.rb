require "minitest/autorun"
require_relative "node.rb"

include BinaryTree

describe Node do
  before do
    @node = Node.new(1)
  end

  it "has an initial value" do
    @node.value.must_equal 1
  end

  it "lets you set a node to left side" do
    lefty = Node.new(2)
    @node.left = lefty
    @node.left.must_equal lefty
  end

  it "lets you set a node to right side" do
    righty = Node.new(2)
    @node.right = righty
    @node.right.must_equal righty
  end

  it "allows initializing nodes" do
    node = Node.new(1, Node.new(2), Node.new(3))
    node.value.must_equal 1
    node.left.value.must_equal 2
    node.right.value.must_equal 3
  end
end

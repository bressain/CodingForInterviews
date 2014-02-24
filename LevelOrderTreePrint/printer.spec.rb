require "minitest/autorun"
require_relative "printer.rb"

include BinaryTree

describe Printer do
  it "prints a single node" do
    node = Node.new(1, Node.new(2), Node.new(3))

    output = Printer.print_level_order(node)

    output.must_equal "1\n2 3"
  end

  it "prints a node with one full left node" do
    node = Node.new(1, Node.new(2), Node.new(3))
    node.left.left = Node.new(4)
    node.left.right = Node.new(5)

    output = Printer.print_level_order(node)

    output.must_equal "1\n2 3\n4 5"
  end

  it "prints a node with full left and right nodes" do
    node = Node.new(1, Node.new(2), Node.new(3))
    node.left.left = Node.new(4)
    node.left.right = Node.new(5)
    node.right.left = Node.new(6)
    node.right.right = Node.new(7)

    output = Printer.print_level_order(node)

    output.must_equal "1\n2 3\n4 5 6 7"
  end

  it "skips blank nodes in unbalanced trees" do
    node = Node.new(1, Node.new(2))
    node.left.right = Node.new(3)
    node.left.right.left = Node.new(4)
    node.left.right.right = Node.new(5)

    output = Printer.print_level_order(node)

    output.must_equal "1\n2\n3\n4 5"
  end
end

module BinaryTree
  class Node
    attr_accessor :value, :left, :right

    def initialize(value, left = nil, right = nil)
      @value = value
      @left = left
      @right = right
    end

    def add_right(node)
      @right = node
    end
  end
end

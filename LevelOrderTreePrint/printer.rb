require_relative "node.rb"

module BinaryTree
  class Printer
    def self.print_level_order(parent_node)
      lines = []
      lines.push([parent_node.value.to_s])
      add_child_lines(parent_node, lines, 1)
      print_lines(lines)
    end

    private

    def self.add_child_lines(node, lines, idx)
      return if not_printable? node

      lines.push([]) if lines.length == idx

      lines[idx].push(node.left.value.to_s) unless node.left.nil?
      lines[idx].push(node.right.value.to_s) unless node.right.nil?

      add_child_lines(node.left, lines, idx + 1)
      add_child_lines(node.right, lines, idx + 1)
    end

    def self.not_printable?(node)
      node.nil? || (node.left.nil? && node.right.nil?)
    end

    def self.print_lines(lines)
      lines
        .map { |x| x.join(" ") }
        .join("\n")
    end
  end
end

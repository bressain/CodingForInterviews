class Quicksort
  def quicksort(array)
    return array if array.length <= 1

    left = []
    right = []
    pivotIdx = left_pivot
    pivot = array[pivotIdx]
    array.each_with_index do |x, i|
      next if i == pivotIdx
      if x <= pivot then left.push(x) else right.push(x) end
    end

    quicksort(left).concat([pivot]).concat(quicksort(right))
  end

  private

  def left_pivot
    0
  end

  def partition(pivot, array)
    left = []
    right = []

    quicksort(left).concat(quicksort(right))
  end
end
class BinarySearch
  def find_item(sorted_array, item_to_find)
    find(sorted_array, item_to_find, midpoint(0, sorted_array.length - 1), 0, sorted_array.length - 1)
  end
  
  private
  def find(sorted_array, item_to_find, idx, min, max)
    return nil if min > max
    return idx if sorted_array[idx] == item_to_find

    mid = midpoint(min, max)
    if sorted_array[idx] > item_to_find
      find(sorted_array, item_to_find, mid, min, idx - 1)
    else
      find(sorted_array, item_to_find, mid, idx + 1, max)
    end
  end

  def midpoint(min, max)
    min + ((max - min) / 2).floor
  end
end